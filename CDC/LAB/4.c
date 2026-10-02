#include <stdio.h>
#include <string.h>
#include <ctype.h>

int isKeyword(char b[])
{
    char kw[32][10] = {
        "auto", "break", "case", "char", "const", "continue", "default", "do",
        "double", "else", "enum", "extern", "float", "for", "goto", "if", "int", "long",
        "register", "return", "short", "signed", "sizeof", "static", "struct", "switch",
        "typedef", "union", "unsigned", "void", "volatile", "while"
    };
    int i;
    for (i = 0; i < 32; i++)
        if (strcmp(kw[i], b) == 0) return 1;
    return 0;
}

int main(void)
{
    char ch, buf[64], op[] = "+-*/%=";
    FILE *fp = fopen("aa.txt", "r");
    int i, j = 0;

    if (!fp) { printf("error opening file\n"); return 1; }

    while ((ch = fgetc(fp)) != EOF)
    {
        for (i = 0; i < 6; i++)
            if (ch == op[i]) printf("%c is operator\n", ch);

        if (isalnum((unsigned char)ch)) {
            if (j < (int)sizeof buf - 1) buf[j++] = ch;
        } else if ((ch == ' ' || ch == '\n' || ch == '\t') && j != 0) {
            buf[j] = '\0'; j = 0;
            printf(isKeyword(buf) ? "%s is keyword\n" : "%s is identifier\n", buf);
        }
    }
    if (j != 0) { buf[j] = '\0'; printf("%s is %s\n", buf, isKeyword(buf) ? "keyword" : "identifier"); }

    fclose(fp);
    return 0;
}
