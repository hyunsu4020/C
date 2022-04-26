/*
 * uecho_client_win.c
 */
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <winsock2.h>

#define BUFSIZE 30
void ErrorHandling(char *message);

int main(int argc, char **argv)
{
	WSADATA  wsaData;
	SOCKET   hSocket;
	char message[30];
	int strLen;
	
	SOCKADDR_IN servAddr;
	
	if(argc!=3){
		printf("Usage : %s <IP> <port>\n", argv[0]);
		exit(1);
	}
	
	if(WSAStartup(MAKEWORD(2, 2), &wsaData) != 0)
		ErrorHandling("WSAStartup() error!");
	
	hSocket=socket(PF_INET, SOCK_DGRAM, 0);
	if(hSocket == INVALID_SOCKET)
		ErrorHandling("socket() error");
	
	memset(&servAddr, 0, sizeof(servAddr));
	servAddr.sin_family=AF_INET;
	servAddr.sin_addr.s_addr=inet_addr(argv[1]);
	servAddr.sin_port=htons(atoi(argv[2]));
	
	if(connect(hSocket, (struct sockaddr*)&servAddr, sizeof(servAddr))==SOCKET_ERROR)
		ErrorHandling("connect() error!");
	
	while(1)
	{
		fputs("전송할 메시지를 입력 하세요 (q to quit) : ", stdout);
		fgets(message, sizeof(message), stdin);
		
		if(!strcmp(message,"q\n"))	break;
		send(hSocket, message, strlen(message), 0);
		
		strLen=recv(hSocket, message, sizeof(message)-1, 0);
		message[strLen]=0;
		printf("서버로부터 전송된 메시지 : %s", message);
	}

	closesocket(hSocket);
	WSACleanup();
	return 0;
}

void ErrorHandling(char *message)
{
	fputs(message, stderr);
	fputc('\n', stderr);
	exit(1);
}
