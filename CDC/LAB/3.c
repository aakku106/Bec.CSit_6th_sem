#include <stdio.h>
#include <ctype.h>
#include <string.h>

int main(void)
{
    char a[64];
    int flag = 1, i;

    printf("Enter an identifier: ");
    if (fgets(a, sizeof a, stdin) == NULL) return 1;
    a[strcspn(a, "\n")] = '\0';

    i = 0;
    if (!(isalpha((unsigned char)a[0]) || a[0] == '_')) flag = 0;
    i = 1;

    while (flag && a[i] != '\0')
    {
        if (!isalnum((unsigned char)a[i]) && a[i] != '_') flag = 0;
        i++;
    }

    printf(flag ? "Valid identifier\n" : "Not a valid identifier\n");
    return 0;
}
