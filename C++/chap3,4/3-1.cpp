#include <iostream>
using namespace std;

class Circle {		// Circle 急攫何
public:
	int radius;
	double getArea();
};

double Circle::getArea() {	// Circle 备泅何
	return 3.14*radius*radius;
}

int main() {
	Circle donut;		// 按眉 donut 积己
	donut.radius = 1;
	double area = donut.getArea();
	cout << "donut 搁利篮 " << area << endl;

	Circle pizza;
	pizza.radius = 30;
	area = pizza.getArea();
	cout << "pizza 搁利篮 " << area << endl;
}
