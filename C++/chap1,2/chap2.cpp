#include <iostream>
#include <cstring>
using namespace std;

int main() {
	std::cout << "���� ���� �� ������ �մϴ�. ����, ����, �� �߿��� �Է��ϼ���\n";

	string s;
	cout << "�ι̿�>>";
	cin >> s; // �ι̿��� �Է��� ���ڿ�

	string t;
	cout << "�ٸ���>>";
	cin >> t;

	if (s == "����" && t == "����")
		cout << "�ι̿��� �̰���ϴ�." << endl;
}