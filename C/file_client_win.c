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

	/* 접속해오는 클라이언트에게 전송해 줄 파일 오픈 */
	fp = fopen("zip.txt", "w");
	if (fp == NULL)
		ErrorHandling("File open error");

	if (WSAStartup(MAKEWORD(2, 2), &wsaData) != 0)
		ErrorHandling("WSAStartup() error!");

	/* 서버 접속위한 소켓 생성 */
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

	/* 데이터를 전송 받아서 파일에 저장한다 */
	while ((len = recv(hSocket, buf, BUFSIZE, 0)) != 0)
	{
		total = total + len;
		fwrite(buf, sizeof(char), len, fp);
	}


	/* 클라이언트가 실제 수신한 총 바이트 수를 출력함 */
	printf("client total bytes received = %d\n", total);


	/* 클라이언트가 수신한 총 바이트 수를 전송 예) 총 수신 바이트 수 = N bytes */
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

// 소켓 함수 오류 출력 후 종료
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

// 소켓 함수 오류 출력
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
