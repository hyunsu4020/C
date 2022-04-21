/*
 * file_client_win.c
 */

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <winsock2.h>

#define BUFSIZE 100
void ErrorHandling(char *message);

int main(int argc, char **argv)
{
	WSADATA  wsaData;
	SOCKET   hSocket;
	
	char buf[BUFSIZE];
	FILE* fp;
	SOCKADDR_IN servAddr;
	int len, n = 0;
	
	if(argc!=3){
		printf("Usage : %s <IP> <port>\n", argv[0]);
		exit(1);
	}
	printf("Client Running ..\n");
	
	fp = fopen("receive.dat", "w");
	if(fp == NULL)
		ErrorHandling("File open error");
	
	if(WSAStartup(MAKEWORD(2, 2), &wsaData) != 0)
		ErrorHandling("WSAStartup() error!");
	
	/* ���� �������� ���� ���� */
	hSocket=socket(PF_INET, SOCK_STREAM, 0);   
	if(hSocket == INVALID_SOCKET)
		ErrorHandling("socket() error");
	
	memset(&servAddr, 0, sizeof(servAddr));
	servAddr.sin_family=AF_INET;
	servAddr.sin_addr.s_addr=inet_addr(argv[1]);
	servAddr.sin_port=htons(atoi(argv[2]));
	
	if( connect(hSocket, (SOCKADDR*)&servAddr, sizeof(servAddr))==SOCKET_ERROR )
		ErrorHandling("connect() error!");
	
	/* �����͸� ���� �޾Ƽ� ���Ͽ� �����Ѵ� */
	while( (len=recv(hSocket, buf, BUFSIZE, 0)) != 0 )
	{
		printf("Data received(%d) = %d \n", ++n, len);		
		fwrite(buf, sizeof(char), len, fp); 
	}
	
	/* ������ �ذͿ� ���� ������ �޽��� ���� */
	send(hSocket, "Thank you\n", 10, 0);

	fclose(fp);
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
