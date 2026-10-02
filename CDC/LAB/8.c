#include <stdio.h>
#include <string.h>
#include <stdlib.h>

char ip[15], stack[15];
int ip_ptr = 0, st_ptr = 0, len;

void check(void)
{
    char t = stack[st_ptr];

    if (t == 'a' || t == 'b')
    {
        stack[st_ptr] = 'E';
        printf("$%s\t\t%s\t\tE->%c\n", stack, ip + ip_ptr, t);
    }
    if (strcmp(stack, "E+E") == 0 || strcmp(stack, "E*E") == 0 || strcmp(stack, "E/E") == 0)
    {
        char op = stack[1];
        strcpy(stack, "E"); st_ptr = 0;
        printf("$%s\t\t%s\t\tE->E%cE\n", stack, ip + ip_ptr, op);
    }
    if (strcmp(stack, "E") == 0 && ip_ptr == len)
    {
        printf("$%s\t\t%s\t\tACCEPT\n", stack, ip + ip_ptr);
        exit(0);
    }
}

int main(void)
{
    int i;

    printf("Grammar: E->E+E | E*E | E/E | a | b\n");
    printf("Enter input string: ");
    if (scanf("%14s", ip) != 1) return 1;
    len = (int)strlen(ip);

    printf("Stack\t\tInput\t\tAction\n");
    for (i = 0; i < len; i++)
    {
        stack[st_ptr] = ip[ip_ptr];
        stack[st_ptr + 1] = '\0';
        ip_ptr++;
        printf("$%s\t\t%s\t\tshift %c\n", stack, ip + ip_ptr, ip[ip_ptr - 1]);
        check();
        st_ptr++;
    }

    printf("REJECT\n");
    return 0;
}
