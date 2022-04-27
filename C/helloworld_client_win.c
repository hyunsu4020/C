/*
 * helloworld_client_win.c
 */

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <winsock2.h>

void ErrorHandling(char *message);

int main(int argc, char **argv)
{
	WSADATA wsaData;
	SOCKET hSocket;
	char message[30];
	int strLen;
	SOCKADDR_IN servAddr;

	if(argc!=3){
		printf("Usage : %s <IP> <port>\n", argv[0]);
		exit(1);
	}

	if(WSAStartup(MAKEWORD(2, 2), &wsaData) != 0) /* Load WinhSocket 2.2 DLL */
		ErrorHandling("WSAStartup() error!");  
	
	hSocket=socket(PF_INET, SOCK_STREAM, 0); /* 서버 접속을 위한 소켓 생성 */
	if(hSocket==INVALID_SOCKET)
		ErrorHandling("hSocketet() error");
	
	memset(&servAddr, 0, sizeof(servAddr));
	servAddr.sin_family=AF_INET;
	servAddr.sin_addr.s_addr=inet_addr(argv[1]);
	servAddr.sin_port=htons(atoi(argv[2]));
	
	if( connect(hSocket, (SOCKADDR*)&servAddr, sizeof(servAddr))==SOCKET_ERROR ) /* 서버로 연결 요청 */
		ErrorHandling("connect() error!");
 
	strLen=recv(hSocket, message, sizeof(message)-1, 0); /* 데이터 수신 */
	if(strLen==-1)
		ErrorHandling("read() error!");
	message[strLen]=0;
	printf("Message from server : %s \n", message);  

	closesocket(hSocket); /* 연결 종료 */
	WSACleanup();
	return 0;
}

void ErrorHandling(char *message)
{
	fputs(message, stderr);
	fputc('\n', stderr);
	exit(1);
}
