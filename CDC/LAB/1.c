#include <stdio.h>
#include <string.h>

int main(void)
{
    char c[30];
    int a = 0, i;

    printf("Enter comment: ");
    if (fgets(c, sizeof c, stdin) == NULL) return 1;
    c[strcspn(c, "\n")] = '\0';

    if (c[0] == '/' && c[1] == '/')
        printf("It is a comment");
    else if (c[0] == '/' && c[1] == '*')
    {
        for (i = 2; c[i] != '\0'; i++)
            if (c[i] == '*' && c[i + 1] == '/') { a = 1; break; }
        printf(a ? "It is a comment" : "It is not a comment");
    }
    else
        printf("It is not a comment");

    printf("\n");
    return 0;
}
