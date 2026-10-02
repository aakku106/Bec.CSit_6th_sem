#include <stdio.h>
#include <string.h>
#include <stdlib.h>

char s[20], stack[20];

int main(void)
{
    /* rows: e b t c f | cols: i + * ( ) $   n = use empty production, p = pop stack top */
    char m[5][6][8] = { { "tb", "",    "",    "tb",  "",   "p" },
                        { "",   "+tb", "",    "",    "n",  "n"  },
                        { "fc", "p",   "",    "fc",  "",   "p" },
                        { "",   "n",   "*fc", "",    "n",  "n"  },
                        { "i",  "",    "",    "(e)", "",   ""  } };
    int size[5][6] = { { 2, 0, 0, 2, 0, 0 },
                       { 0, 3, 0, 0, 1, 1 },
                       { 2, 0, 0, 2, 0, 0 },
                       { 0, 1, 3, 0, 1, 1 },
                       { 1, 0, 0, 3, 0, 0 } };
    int i = 1, j = 0, k, n, str1, str2;

    printf("Enter input string: ");
    if (scanf("%15s", s) != 1) return 1;
    strcat(s, "$");
    n = (int)strlen(s);

    stack[0] = '$'; stack[1] = 'e';

    printf("Stack\t\tInput\n");
    while (stack[i] != '$')
    {
        if (stack[i] == s[j]) { i--; j++; goto show; }

        switch (stack[i]) {
            case 'e': str1 = 0; break;
            case 'b': str1 = 1; break;
            case 't': str1 = 2; break;
            case 'c': str1 = 3; break;
            case 'f': str1 = 4; break;
            default:  str1 = -1; break;
        }
        switch (s[j]) {
            case 'i': str2 = 0; break;
            case '+': str2 = 1; break;
            case '*': str2 = 2; break;
            case '(': str2 = 3; break;
            case ')': str2 = 4; break;
            case '$': str2 = 5; break;
            default:  str2 = -1; break;
        }

        if (str1 < 0 || str2 < 0 || m[str1][str2][0] == '\0') { printf("ERROR\n"); return 0; }
        else if (m[str1][str2][0] == 'n') i--;
        else if (m[str1][str2][0] == 'p') i--;
        else if (m[str1][str2][0] == 'i') stack[i] = 'i';
        else {
            for (k = size[str1][str2] - 1; k >= 0; k--) { stack[i] = m[str1][str2][k]; i++; }
            i--;
        }

show:
        for (k = 0; k <= i; k++) printf("%c", stack[k]);
        printf("\t\t");
        for (k = j; k < n; k++) printf("%c", s[k]);
        printf("\n");
    }

    printf("SUCCESS\n");
    return 0;
}
