#include <stdio.h>
#include <string.h>
#include <stdlib.h>

int j = 0, tmpch = 90;
char str[100], left[64] = "", right[64] = "";
struct { int pos; char op; } k[15];

void findopr(void)
{
    int i, oi;
    char ops[] = "/*+-";
    for (oi = 0; ops[oi]; oi++)
        for (i = 0; str[i] != '\0'; i++)
            if (str[i] == ops[oi]) { k[j].pos = i; k[j++].op = ops[oi]; }
}

void fleft(int x)
{
    int w = 0, flag = 0;
    x--;
    while (x != -1 && str[x] != '+' && str[x] != '*' && str[x] != '-' && str[x] != '/' && str[x] != '=')
    {
        if (str[x] != '$' && !flag) { left[w++] = str[x]; left[w] = '\0'; str[x] = '$'; flag = 1; }
        x--;
    }
}

void fright(int x)
{
    int w = 0, flag = 0;
    x++;
    while (str[x] != '\0' && str[x] != '+' && str[x] != '*' && str[x] != '-' && str[x] != '/' && str[x] != '=')
    {
        if (str[x] != '$' && !flag) { right[w++] = str[x]; right[w] = '\0'; str[x] = '$'; flag = 1; }
        x++;
    }
}

int main(void)
{
    int i;

    printf("Enter expression: ");
    if (scanf("%99s", str) != 1) return 1;

    findopr();
    for (i = 0; i < j; i++)
    {
        left[0] = right[0] = '\0';
        fleft(k[i].pos); fright(k[i].pos);
        str[k[i].pos] = (char)tmpch--;
        printf("t%d := %s %c %s\n", 90 - tmpch, left, k[i].op, right);
    }
    return 0;
}
