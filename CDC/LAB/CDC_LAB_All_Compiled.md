---
dg-publish: true
Subject: "[[CDC]]"
---
# CDC Lab — Individual Programs, Built with `-O3`

Every lab in [[CDC_LAB_All]] split into its own file and compiled. Source is `1.c` … `9b.c`, binaries are `1` … `9b` in this folder.

## Build

```sh
cd CDC/LAB
for f in 1 2 3 4 5 6 7 8 9a 9b; do clang -O3 -Wall -o "$f" "$f.c"; done
```

| Source | Binary | Program | Verified input → result |
| --- | --- | --- | --- |
| `1.c` | `1` | Valid comment checker | `/* hello */` → `It is a comment` |
| `2.c` | `2` | Strings over `a*`, `a*b+`, `abb` | `aabb` → `accepted under 'a*b+'` |
| `3.c` | `3` | Valid identifier checker | `a-b` → `Not a valid identifier` |
| `4.c` | `4` | Lexical analyser (reads `aa.txt`) | `int x = y;` → `int is keyword`, `x is identifier`, `= is operator` |
| `5.c` | `5` | FIRST of a grammar | `S=aB, B=b, B=$` → `FIRST(S)={a}`, `FIRST(B)={b $}` |
| `6.c` | `6` | FOLLOW of a grammar | `S=aAb, A=b` → `FOLLOW(A)={b}` |
| `7.c` | `7` | LL(1) table-driven parser | `i+i*i` → `SUCCESS`; `i+` → `ERROR` |
| `8.c` | `8` | Shift-reduce parser | `a+b` → `ACCEPT` |
| `9a.c` | `9a` | Intermediate code generation | `a+b*c-d` → 3 three-address codes |
| `9b.c` | `9b` | Target code generation (reads `input.txt`, writes `output.txt`) | 4 quads → `MOV/ADD/MUL` sequence |

All 10 compile with zero warnings under `-O3 -Wall`.

## How to run

Run from inside this folder, so the two file-reading labs can find their data files.

| # | Command | Type this | Shows |
| --- | --- | --- | --- |
| 1 | `./1` | `/* hi */` | `It is a comment` |
| 2 | `./2` | `aabb` | `aabb accepted under 'a*b+'` |
| 3 | `./3` | `a-b` | `Not a valid identifier` |
| 4 | `./4` | *(reads `aa.txt`, no input)* | 4 lines: keyword, identifier, operator, identifier |
| 5 | `./5` | `3`⏎`S=aB`⏎`B=b`⏎`B=$`⏎`S`⏎`n` | `FIRST(S) = { a }` |
| 6 | `./6` | `2`⏎`S=aAb`⏎`A=b`⏎`A`⏎`0` | `FOLLOW(A) = { b }` |
| 7 | `./7` | `i+i*i` | stack/input trace, ends `SUCCESS` |
| 8 | `./8` | `a+b` | shift/reduce trace, ends `ACCEPT` |
| 9a | `./9a` | `a+b*c` | `t1 := b * c` / `t2 := a + Z` |
| 9b | `./9b` | *(reads `input.txt`, no input)* | writes `output.txt` |

`⏎` is Enter. Two sample data files are included:

`aa.txt` — one line, `int a + b`. Spaces around the operator matter, otherwise `a+b` is read as the single identifier `ab`.

```
int a + b
```

`input.txt` — two quadruples, one assignment and one addition.

```
= a 0 t1
+ b t1 t2
```

## Input formats worth writing down

**Labs 5 and 6** — productions are read with `%s` and the right-hand side is assumed to start at **index 2**, so write them with a single `=`, not `->`:

```
3
S=aB
B=b
B=$
```

`$` (lab 5) and `#` (lab 6) mean the empty production. Typing `S->aB` makes the program read the `>` as a terminal.

**Lab 4** — needs a file called `aa.txt` in the working directory. Only space, newline and tab separate tokens, so `a*b` correctly yields two operators but `(a)` leaves `a` unflushed until the next space.

**Lab 9b** — needs `input.txt`, four whitespace-separated fields per line:

```
= a 0 t1
+ b t1 t2
* c t2 t3
```

writes `MOV`/`ADD`/`SUB`/`MUL`/`DIV` to `output.txt`.

## Changes made to the code in [[CDC_LAB_All]]

The algorithms are unchanged; these are the fixes needed to actually build and run.

- **Labs 1, 2, 3** — `gets()` is gone in modern C (removed in C23). Replaced with `fgets()` plus `strcspn` to strip the newline, which also makes the identifier buffer large enough for real input.
- **Lab 4** — `buf` raised from 15 to 64 bytes with a bounds check; the trailing token is flushed at EOF so the last word is not dropped; `isalpha`/`isalnum` get an `unsigned char` cast.
- **Lab 5, 6** — production buffers widened; `isalpha` cast added; `sub` is reset before each use in `follow`, which was reading leftover characters from the previous call.
- **Lab 7** — this one had genuine parser bugs, it reported `ERROR` for *every* multi-token input:
  - after matching a terminal the old code fell through into a table lookup on the *already decremented* indices, so it looked up `M[c][+]` immediately after matching `f → i`. It now prints the state and continues.
  - the table was missing `c → ε` on `+` and on `)`, and had no way to return from a completed `t` to `e`. Added `n` entries in those cells and a `p` (pop) entry, with `p` added to `e` and `t` on `$`.
  - the loop condition was `stack[i] != '$' && s[j] != '$'`, so a truncated string like `i+` printed `SUCCESS` — it now runs until the stack is empty and reports `ERROR` correctly.
- **Lab 9a** — `left`/`right` are cleared before each extraction, so an expression with no operator on one side no longer prints uninitialised bytes.
- **Lab 9b** — the four `fscanf` fields were sized 5/5/5/5 bytes, too small for names like `t10`; widened, plus null checks on both files and a message on completion.

## Sample runs

Lab 7, `i+i*i`:

```
Stack		Input
$bt		i+i*i$
$bcf		i+i*i$
$bci		i+i*i$
$bc		+i*i$
$b		+i*i$
$bt+		+i*i$
$bt		i*i$
$bcf		i*i$
$bci		i*i$
$bc		*i$
$bcf*		*i$
$bcf		i$
$bci		i$
$bc
$b
$
SUCCESS
```

Lab 8, `a+b`:

```
Stack		Input		Action
$a		+b		shift a
$E		+b		E->a
$E+		b		shift +
$E+b				shift b
$E+E				E->b
$E				E->E+E
$E				ACCEPT
```

Lab 9a, `a+b*c-d`:

```
t1 := b * c
t2 := a + Z
t3 := Y - d
```

Lab 9b, target code for `= a 0 t1 / + b t1 t2 / * c t2 t3`:

```
MOV R0,a
MOV t1,R0
MOV R0,b
ADD R0,t1
MOV t2,R0
MOV R0,c
MUL R0,t2
MOV t3,R0
```

`Z` and `Y` in the lab 9a output are the internal temp placeholders written back into the expression string; they are not printed operands.
