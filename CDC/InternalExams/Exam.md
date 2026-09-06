---
Subject: "[[CDC]]"
Topic: Important Questions Analysis
Sets Analyzed: 2075, 2076, 2078, 2080, 2081, Model I, Model II
tags:
  - exam
  - cdc
  - analysis
---

# CDC — Topic-wise Frequency Analysis & Priority List

Based on 7 old question sets (2081(new) had no questions available, so excluded from counting).

## Tier 1 — Most Important (appear in almost every set)

| Topic                                                                                              | Appeared In                                     | Count                      | Typical Ask                                             |
| -------------------------------------------------------------------------------------------------- | ----------------------------------------------- | -------------------------- | ------------------------------------------------------- |
| Regex → NFA → DFA (Thompson's + subset construction) & DFA minimization                            | 2075, 2076, 2078, 2080, 2081, Model I           | 6/7                        | Convert given RE to DFA; minimize DFA                   |
| Parsing table construction (LL(1) / SLR / LR(1))                                                   | 2075, 2076, 2078, 2080, 2081, Model I, Model II | 7/7                        | Construct table + test/parse a string                   |
| Three Address Code, Quadruples & Triples                                                           | 2075, 2076, 2078, 2080, 2081, Model I           | 6/7                        | Convert given code/expression to TAC/quadruples/triples |
| Code Optimization techniques (loop opt, constant folding, dead-code, peephole, strength reduction) | 2075, 2076, 2078, 2080, 2081, Model I, Model II | 7/7                        | Explain + apply on given code                           |
| FIRST and FOLLOW computation                                                                       | 2075, 2080, 2081, Model I                       | 4/7 (but heavily weighted) | Compute FIRST/FOLLOW of non-terminals                   |
| Type Checking (static/dynamic, SDD-based)                                                          | 2075, 2076, 2078, 2080, Model II                | 5/7                        | SDD for type checking / static vs dynamic               |
| SDD / Annotated Parse Tree / Syntax-directed translation                                           | 2075, 2076, 2080, 2081, Model II                | 5/7                        | Construct annotated parse tree for given SDD            |
| Activation Record / Activation Tree                                                                | 2075, 2078, 2080, 2081, Model II                | 5/7                        | Draw structure / explain caller-callee activities       |
| Symbol Table (functions, entries, data structures)                                                 | 2075, 2078, 2080, 2081, Model II                | 5/7                        | List entries; compare data structures                   |
| Factors affecting Code Generator / Target Code Generation                                          | 2075, 2076, 2078, 2080, 2081                    | 5/7                        | Discuss factors / design issues                         |

## Tier 2 — Important (moderate repetition, 2–4 sets)

| Topic                                                     | Appeared In                      | Count | Typical Ask                                   |
| --------------------------------------------------------- | -------------------------------- | ----- | --------------------------------------------- |
| Compiler phases / block diagram / Compiler vs Interpreter | 2075, 2076, 2078, 2081, Model II | 5/7   | Explain phases with diagram                   |
| Backpatching                                              | 2081, Model I (×2)               | 3/7   | Backpatching for boolean expr / while-if code |
| Synthesized vs Inherited Attributes                       | 2078, 2080, 2081, Model II       | 4/7   | Differentiate with example                    |
| LR(1) Items / Closure / GOTO / Core items                 | 2078, 2081, Model II (×2)        | 4/7   | Compute closure/GOTO steps                    |
| Shift-Reduce Parsing                                      | 2076, 2078                       | 2/7   | Show shift-reduce actions for a string        |
| Recursive Descent Parsing                                 | 2075, Model I                    | 2/7   | Differentiate / write parser & trace          |
| LL(1) Parsing Table & Properties                          | 2080, Model I (×2)               | 3/7   | Construct table, check LL(1) validity         |
| Error Handling in Compiler                                | 2076, Model I                    | 2/7   | Role/importance across phases                 |
| Intermediate Code representation methods                  | 2076, 2081                       | 2/7   | Different IR methods with example             |

## Tier 3 — If Time Remains (appeared once, but still asked)

| Topic                                           | Appeared In    | Typical Ask                           |
| ----------------------------------------------- | -------------- | ------------------------------------- |
| Left Recursion removal                          | 2078           | Remove left recursion from grammar    |
| DAG vs Syntax Tree                              | 2081           | Differentiate + represent expression  |
| Macro vs Procedure / Macro Expansion            | Model II       | Expand nested macros                  |
| Register Allocation (Graph Coloring)            | Model I        | Interference graph + assign registers |
| Basic Blocks & Flow Graph / Loop-invariant code | 2080, Model II | Identify basic blocks, flow graph     |
| Operator-Precedence Parsing                     | Model II       | Build precedence table, parse string  |
| Ambiguous Grammar / Dangling-Else problem       | Model I        | Explain + resolve                     |
| Parameter Passing Mechanisms                    | Model I        | Call by value/reference/name          |
| Reduce-Reduce Conflict example                  | 2081           | Give example + SLR table              |
| Runtime Storage Management techniques           | 2078           | List types                            |
| Hash-table symbol table implementation          | Model II       | Build hash table with chaining        |

## Study Priority Summary

1. **Master first:** Parsing (LL(1)/SLR/LR(1) table construction + parsing a string), NFA/DFA conversion & minimization, TAC/Quadruples/Triples, Code Optimization, FIRST/FOLLOW — these alone cover the majority of marks across every single year.
2. **Then cover:** SDD/annotated parse trees, type checking, symbol table, activation records, factors affecting code generation, compiler phases.
3. **Last, if time remains:** Backpatching details, attributes (synthesized/inherited), macros, register allocation, flow graphs, operator-precedence parsing, and short-note style topics (error recovery, parameter passing).

> Note: Numerical/construction-based questions (DFA, parsing tables, TAC, FIRST/FOLLOW) dominate every paper — practicing these with different grammars is higher-value than memorizing definitions alone.
