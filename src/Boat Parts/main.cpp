#include "pch.h"

using namespace std;

bool check(list<string> partList, string part) {
    list<string>::iterator uit;

    for (uit = partList.begin();uit != partList.end();uit++) {
        if (*uit == part) {
            return true;
        }
    }
    return false;
}

int main()
{
    int P, N;

    int day = 0, lastDay = 0;
    cin >> P >> N;
    string part;
    list<string> parts, uniqueParts;
    list<string>::iterator it, uit;

    for (int i = 0;i < N;i++) {
        cin >> part;
        parts.push_back(part);
    }
    for (it = parts.begin();it != parts.end(); ++it) {
        day++;
        if (!check(uniqueParts, *it)) {
            uniqueParts.push_back(*it);
            lastDay = day;
        }
    }
    if (uniqueParts.size() < P) {
        cout << "paradox avoided";
    }
    else {
        cout << lastDay;
    }
    return 0;
}
