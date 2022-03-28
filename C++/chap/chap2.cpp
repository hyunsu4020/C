#include <iostream>
#include <cstring>
using namespace std;

int main() {
	std::cout << "가위 바위 보 게임을 합니다. 가위, 바위, 보 중에서 입력하세요\n";

	string s;
	cout << "로미오>>";
	cin >> s; // 로미오가 입력한 문자열

	string t;
	cout << "줄리엣>>";
	cin >> t;

	if (s == "가위" && t == "바위")
		cout << "로미오가 이겼습니다." << endl;
}