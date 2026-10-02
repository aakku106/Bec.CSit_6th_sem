#include <stdio.h>
#include <string.h>

int main(void)
{
    char s[20], c;
    int state = 0, i = 0;

    printf("Enter a string: ");
    if (fgets(s, sizeof s, stdin) == NULL) return 1;
    s[strcspn(s, "\n")] = '\0';

    while (s[i] != '\0')
    {
        c = s[i++];
        switch (state)
        {
            case 0: state = (c == 'a') ? 1 : (c == 'b') ? 2 : 6; break;
            case 1: state = (c == 'a') ? 3 : (c == 'b') ? 4 : 6; break;
            case 2: state = (c == 'b') ? 2 : 6; break;
            case 3: state = (c == 'a') ? 3 : (c == 'b') ? 2 : 6; break;
            case 4: state = (c == 'b') ? 5 : 6; break;
            case 5: state = (c == 'b') ? 2 : 6; break;
        }
        if (state == 6) { printf("%s is not recognized\n", s); return 0; }
    }

    if (state == 1) printf("%s accepted under 'a'\n", s);
    else if (state == 2 || state == 4) printf("%s accepted under 'a*b+'\n", s);
    else if (state == 5) printf("%s accepted under 'abb'\n", s);

    return 0;
}
