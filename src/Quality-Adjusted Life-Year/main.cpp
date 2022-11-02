#include "pch.h"

using namespace std;

int main()
{
    int numPeriod;
    float sum, quality, years;
    sum = 0;
    cin >> numPeriod;
    for (int i = 0;i < numPeriod;i++) {
        cin >> quality >> years;
        sum += quality * years;
    }
    cout << sum;
}
