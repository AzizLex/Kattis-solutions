#include "pch.h"

using namespace std;

int main()
{
    int n;
    int a = 0;

    cin >> n;
    int* xy = new int[2 * n];

    for (int i = 0;i < n;i++) {
        cin >> *(xy + 2 * i) >> *(xy + 2 * i + 1);
    }
    for (int i = 0;i < n;i++) {
        a += *(xy + 2 * i + 1) - *(xy + 2 * i);
    }

    cout << (float)a / (float)n;
    return 0;
}
