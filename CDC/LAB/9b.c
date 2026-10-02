#include <stdio.h>
#include <string.h>

int main(void)
{
    char op[8], arg1[16], arg2[16], result[16];
    FILE *fp1 = fopen("input.txt", "r");
    FILE *fp2 = fopen("output.txt", "w");

    if (!fp1) { printf("error opening input.txt\n"); return 1; }
    if (!fp2) { fclose(fp1); printf("error opening output.txt\n"); return 1; }

    while (fscanf(fp1, "%7s%15s%15s%15s", op, arg1, arg2, result) != EOF)
    {
        if (strcmp(op, "=") == 0)
        {
            fprintf(fp2, "MOV R0,%s\n", arg1);
            fprintf(fp2, "MOV %s,R0\n", result);
            continue;
        }

        const char *ins = strcmp(op, "+") == 0 ? "ADD" :
                          strcmp(op, "-") == 0 ? "SUB" :
                          strcmp(op, "*") == 0 ? "MUL" : "DIV";

        fprintf(fp2, "MOV R0,%s\n", arg1);
        fprintf(fp2, "%s R0,%s\n", ins, arg2);
        fprintf(fp2, "MOV %s,R0\n", result);
    }

    fclose(fp1);
    fclose(fp2);
    printf("Target code written to output.txt\n");
    return 0;
}
