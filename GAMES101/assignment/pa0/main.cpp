#include "../eigen3/Eigen/Core"
#include "../eigen3/Eigen/Dense"

#include<cmath>
#include<iostream>

// 1 - 3

/*
    齐次坐标：N+1位补1.0
    旋转：可以通过变换i帽，j帽的方式首先变换坐标系来获取旋转后的结果（左乘）；
    平移：左乘；
*/

/*
    1. 旋转45°
    2. 平移(1, 2)
    3. 要求用齐次坐标
*/
void h1(Eigen::Vector3f point)
{
    std::cout << "rotation before \n";
    std::cout << point << std::endl;

    float cos45 = std::cos(45.0/180.0*acos(-1));
    float sin45 = std::sin(45.0/180.0*acos(-1));

    std::cout << "cos45=" << cos45 << std::endl;

    Eigen::Matrix3f mat, mat2;
    mat << cos45, -1.0 * sin45, 0.0, sin45, cos45, 0.0, 0.0, 0.0, 1.0;
    mat2 << 1.0, 0.0, 1.0, 0.0, 1.0, 2.0, 0.0, 0.0, 1.0;

    Eigen::Vector3f afterTrans = mat2 * mat * point;

    std::cout << "transform after = \n";
    std::cout << afterTrans << std::endl;
}

int main(){

    // Basic Example of cpp
    std::cout << "Example of cpp \n";
    float a = 1.0, b = 2.0;
    std::cout << a << std::endl;    
    std::cout << a/b << std::endl;          
    std::cout << std::sqrt(b) << std::endl;     // 1.414
    std::cout << std::acos(-1) << std::endl;    // 弧度制 - cos(180) = -1 3.14159
    std::cout << std::sin(30.0/180.0*acos(-1)) << std::endl; // sin(30/180*3.14) = 0.5

    // Example of vector
    std::cout << "Example of vector \n";
    // vector definition
    Eigen::Vector3f v(1.0f,2.0f,3.0f);
    Eigen::Vector3f w(1.0f,0.0f,0.0f);
    // vector output
    std::cout << "Example of output \n";
    std::cout << v << std::endl;
    // vector add
    std::cout << "Example of add \n";
    std::cout << v + w << std::endl;
    // vector scalar multiply
    std::cout << "Example of scalar multiply \n";
    std::cout << v * 3.0f << std::endl;
    std::cout << 2.0f * v << std::endl;

    // Example of matrix
    std::cout << "Example of matrix \n";
    // matrix definition
    Eigen::Matrix3f i,j;
    i << 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0;
    j << 2.0, 3.0, 1.0, 4.0, 6.0, 5.0, 9.0, 7.0, 8.0;
    // matrix output
    std::cout << "Example of output \n";
    std::cout << "i = \n";
    std::cout << i << std::endl;
    std::cout << "j = \n";
    std::cout << j << std::endl;
    std::cout << "Example of add" << std::endl;
    std::cout << i + j << std::endl;
    std::cout << "Example multiply scaler" << std::endl;
    std::cout << i * 2.0 << std::endl;
    std::cout << "Example multiply i * j = " << std::endl;
    std::cout << i * j << std::endl;        // A的行分别乘以B的列
    std::cout << "Example multiply i * v = " << std::endl;
    std::cout << i * v << std::endl;

    // matrix add i + j
    // matrix scalar multiply i * 2.0
    // matrix multiply i * j
    // matrix multiply vector i * v

    /*
        QUESTION!
            1. 向量和行列式or竖列式
            2. 向量和矩阵是用的是左乘or右乘
    */

    Eigen::Vector3f point(2.0, 1.0, 1.0);
    h1(point);

    return 0;
}