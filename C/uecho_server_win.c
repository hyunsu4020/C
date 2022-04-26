/*
 * uecho_server_win.c
 */
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <winsock2.h>

#define BUFSIZE 30
void ErrorHandling(char *message);

int main(int argc, char **argv)
{
	WSADATA	wsaData;
	SOCKET	hServSock;
	char message[BUFSIZE];
	int strLen;
	
	SOCKADDR_IN servAddr;
	SOCKADDR_IN clntAddr;
	int clntAddrSize;
	
	if(argc!=2){
		printf("Usage : %s <port>\n", argv[0]);
		exit(1);
	}
	
	if(WSAStartup(MAKEWORD(2, 2), &wsaData) != 0)
		ErrorHandling("WSAStartup() error!");
	
	hServSock=socket(PF_INET, SOCK_DGRAM, 0);
	if(hServSock == INVALID_SOCKET)
		ErrorHandling("socket() error!");
	
	memset(&servAddr, 0, sizeof(servAddr));
	servAddr.sin_family=AF_INET;
	servAddr.sin_addr.s_addr=htonl(INADDR_ANY);
	servAddr.sin_port=htons(atoi(argv[1]));
	
	if (bind(hServSock, (SOCKADDR*) &servAddr, sizeof(servAddr))==SOCKET_ERROR)
		ErrorHandling("bind() error");
	
	while(1) {
		clntAddrSize=sizeof(clntAddr);
		strLen = recvfrom(hServSock, message, BUFSIZE, 0, (SOCKADDR*)&clntAddr, &clntAddrSize);
		sendto(hServSock, message, strLen, 0, (SOCKADDR*)&clntAddr, sizeof(clntAddr));
	}
	
	closesocket(hServSock);
	WSACleanup();
	return 0;
}

void ErrorHandling(char *message)
{
	fputs(message, stderr);
	fputc('\n', stderr);
	exit(1);
}
