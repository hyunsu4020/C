/*
 * file_client_win.c
 */

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <winsock2.h>
#include <ws2tcpip.h>

#pragma warning(disable:4996)
#define BUFSIZE 30
void ErrorHandling(char* message);
void err_quit(char* msg);
void err_display(char* msg);

int main(int argc, char** argv)
{
	WSADATA  wsaData;
	SOCKET   hSocket;

	char buf[BUFSIZE];
	FILE* fp;
	SOCKADDR_IN servAddr;
	int len;
	int total = 0;

	if (argc != 3) {
		printf("Usage : %s <IP> <port>\n", argv[0]);
		exit(1);
	}
	printf("Client Running\n");

	/* �����ؿ��� Ŭ���̾�Ʈ���� ������ �� ���� ���� */
	fp = fopen("zip.txt", "w");
	if (fp == NULL)
		ErrorHandling("File open error");

	if (WSAStartup(MAKEWORD(2, 2), &wsaData) != 0)
		ErrorHandling("WSAStartup() error!");

	/* ���� �������� ���� ���� */
	hSocket = socket(PF_INET, SOCK_STREAM, 0);
	if (hSocket == INVALID_SOCKET)
		ErrorHandling("socket() error");

	memset(&servAddr, 0, sizeof(servAddr));
	servAddr.sin_family = AF_INET;
	//inet_pton(AF_INET, (PCSTR)argv[1], (PVOID)servAddr.sin_addr.s_addr);
	servAddr.sin_addr.s_addr = inet_addr(argv[1]);
	servAddr.sin_port = htons(atoi(argv[2]));

	if (connect(hSocket, (SOCKADDR*)&servAddr, sizeof(servAddr)) == SOCKET_ERROR)
		ErrorHandling("connect() error!");

	/* �����͸� ���� �޾Ƽ� ���Ͽ� �����Ѵ� */
	while ((len = recv(hSocket, buf, BUFSIZE, 0)) != 0)
	{
		total = total + len;
		fwrite(buf, sizeof(char), len, fp);
	}


	/* Ŭ���̾�Ʈ�� ���� ������ �� ����Ʈ ���� ����� */
	printf("client total bytes received = %d\n", total);


	/* Ŭ���̾�Ʈ�� ������ �� ����Ʈ ���� ���� ��) �� ���� ����Ʈ �� = N bytes */
	send(hSocket, "Thank you\n", 10, 0);

	fclose(fp);
	closesocket(hSocket);

	WSACleanup();
	return 0;
}

void ErrorHandling(char* message)
{
	fputs(message, stderr);
	fputc('\n', stderr);
	exit(1);
}

// ���� �Լ� ���� ��� �� ����
void err_quit(char* msg)
{
	LPVOID lpMsgBuf;
	FormatMessage(
		FORMAT_MESSAGE_ALLOCATE_BUFFER | FORMAT_MESSAGE_FROM_SYSTEM,
		NULL, WSAGetLastError(),
		MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT),
		(LPTSTR)&lpMsgBuf, 0, NULL);
	MessageBox(NULL, (LPCTSTR)lpMsgBuf, msg, MB_ICONERROR);
	LocalFree(lpMsgBuf);
	exit(1);
}

// ���� �Լ� ���� ���
void err_display(char* msg)
{
	LPVOID lpMsgBuf;
	FormatMessage(
		FORMAT_MESSAGE_ALLOCATE_BUFFER | FORMAT_MESSAGE_FROM_SYSTEM,
		NULL, WSAGetLastError(),
		MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT),
		(LPTSTR)&lpMsgBuf, 0, NULL);
	printf("[%s] %s", msg, (char*)lpMsgBuf);
	LocalFree(lpMsgBuf);
}
