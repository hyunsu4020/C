#include <iostream>
using namespace std;

class Circle {		// Circle �����
public:
	int radius;
	double getArea();
};

double Circle::getArea() {	// Circle ������
	return 3.14*radius*radius;
}

int main() {
	Circle donut;		// ��ü donut ����
	donut.radius = 1;
	double area = donut.getArea();
	cout << "donut ������ " << area << endl;

	Circle pizza;
	pizza.radius = 30;
	area = pizza.getArea();
	cout << "pizza ������ " << area << endl;
}
