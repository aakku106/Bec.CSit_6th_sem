#include <stdio.h>
#include <ctype.h>

int n;
char prod[10][20], result[40];

void addTo(char R[], char v)
{
    int k;
    for (k = 0; R[k] != '\0'; k++)
        if (R[k] == v) return;
    R[k] = v; R[k + 1] = '\0';
}

void FIRST(char *R, char c)
{
    int i, j, k, eps;
    char sub[40];

    R[0] = '\0';
    if (!isupper((unsigned char)c)) { addTo(R, c); return; }

    for (i = 0; i < n; i++)
    {
        if (prod[i][0] != c) continue;

        if (prod[i][2] == '$')
            addTo(R, '$');
        else
        {
            j = 2;
            while (prod[i][j] != '\0')
            {
                eps = 0;
                FIRST(sub, prod[i][j]);
                for (k = 0; sub[k] != '\0'; k++)
                {
                    addTo(R, sub[k]);
                    if (sub[k] == '$') eps = 1;
                }
                if (!eps) break;
                j++;
            }
        }
    }
}

int main(void)
{
    int i;
    char ch, choice;

    printf("No. of productions: ");
    if (scanf("%d", &n) != 1) return 1;

    for (i = 0; i < n; i++) {
        printf("Production %d (format S=aB, use $ for epsilon): ", i + 1);
        if (scanf("%19s", prod[i]) != 1) return 1;
    }

    do {
        printf("Find FIRST of: ");
        if (scanf(" %c", &ch) != 1) break;
        FIRST(result, ch);
        printf("FIRST(%c) = { ", ch);
        for (i = 0; result[i] != '\0'; i++) printf("%c ", result[i]);
        printf("}\n");
        printf("Continue(y/n)? ");
        if (scanf(" %c", &choice) != 1) break;
    } while (choice == 'y' || choice == 'Y');

    return 0;
}
