#include <stdio.h>
#include <string.h>
#include <ctype.h>

int n;
char a[10][20], result[40];

void addTo(char R[], char v)
{
    int k;
    for (k = 0; R[k] != '\0'; k++)
        if (R[k] == v) return;
    R[k] = v; R[k + 1] = '\0';
}

void first(char *R, char c);
void follow(char *R, char c);

void follow(char *R, char c)
{
    int i, j, k, len;
    char sub[40];

    R[0] = '\0';
    if (a[0][0] == c) addTo(R, '$');

    for (i = 0; i < n; i++) {
        len = (int)strlen(a[i]);
        for (j = 2; j < len; j++)
            if (a[i][j] == c)
            {
                sub[0] = '\0';
                if (a[i][j + 1] != '\0')
                    first(sub, a[i][j + 1]);
                else if (c != a[i][0])
                    follow(sub, a[i][0]);
                for (k = 0; sub[k] != '\0'; k++) addTo(R, sub[k]);
            }
    }
}

void first(char *R, char c)
{
    int k;
    if (!isupper((unsigned char)c) && c != '#') { addTo(R, c); return; }
    for (k = 0; k < n; k++)
        if (a[k][0] == c)
        {
            if (a[k][2] == '#') follow(R, a[k][0]);
            else if (!isupper((unsigned char)a[k][2])) addTo(R, a[k][2]);
            else first(R, a[k][2]);
        }
}

int main(void)
{
    int i, choice;
    char c;

    printf("No. of productions: ");
    if (scanf("%d", &n) != 1) return 1;

    for (i = 0; i < n; i++) {
        printf("Production %d (format A=aB, use # for epsilon): ", i + 1);
        if (scanf("%19s", a[i]) != 1) return 1;
    }

    do {
        printf("Find FOLLOW of: ");
        if (scanf(" %c", &c) != 1) break;
        follow(result, c);
        printf("FOLLOW(%c) = { ", c);
        for (i = 0; result[i] != '\0'; i++) printf("%c ", result[i]);
        printf("}\n");
        printf("Continue(1/0)? ");
        if (scanf("%d", &choice) != 1) break;
    } while (choice == 1);

    return 0;
}
