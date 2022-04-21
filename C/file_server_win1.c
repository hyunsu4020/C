/*
 * file_server_win.c
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
	SOCKET   hServSock;
	SOCKET   hClntSock;
	char buf[BUFSIZE];
	
	FILE* fp;
	SOCKADDR_IN servAddr;
	SOCKADDR_IN clntAddr;
	int clntAddrSize;
	int len, n = 0;
	char stop;
	
	if(argc!=2){
		printf("Usage : %s <port>\n", argv[0]);
		exit(1);
	}
	printf("Server Running ...\n");
	
	/* �����ؿ��� Ŭ���̾�Ʈ���� ������ �� ���� ����  */
	fp = fopen("file_server_win1.c", "r");
	if(fp == NULL)
		ErrorHandling("File open error");
	
	if(WSAStartup(MAKEWORD(2, 2), &wsaData) != 0)
		ErrorHandling("WSAStartup() error!");
	
	hServSock=socket(PF_INET, SOCK_STREAM, 0);   
	if(hServSock == INVALID_SOCKET)
		ErrorHandling("socket() error");
	
	memset(&servAddr, 0, sizeof(servAddr));
	servAddr.sin_family=AF_INET;
	servAddr.sin_addr.s_addr=htonl(INADDR_ANY);
	servAddr.sin_port=htons(atoi(argv[1]));
	
	if( bind(hServSock, (SOCKADDR*) &servAddr, sizeof(servAddr))==SOCKET_ERROR )
		ErrorHandling("bind() error");
	
	if( listen(hServSock, 5)==SOCKET_ERROR )
		ErrorHandling("listen() error");
	
	clntAddrSize=sizeof(clntAddr);    
	hClntSock=accept(hServSock, (SOCKADDR*)&clntAddr,&clntAddrSize);
	if(hClntSock==INVALID_SOCKET)
		ErrorHandling("accept() error");
	
	/* Ŭ���̾�Ʈ�� ������ ���� */
	while(1){	
		len=fread(buf, sizeof(char), BUFSIZE, fp);
		printf("Data read(%d) = %d \n", ++n, len);
		send(hClntSock, buf, len, 0);
		if(feof(fp)) break;
	}
	
	/* ������ ������ ������ �Ϻ�(���ۿ���)�� ���� */
	if(shutdown(hClntSock, SD_SEND) ==SOCKET_ERROR )
		ErrorHandling("shutdown error");
	
	/* �λ��� �޽����� ���� */
	len = recv(hClntSock, buf, BUFSIZE-1, 0);
	buf[len]=0;
	fputs(buf, stdout);
	
	fclose(fp);
	closesocket(hClntSock);
	
	WSACleanup();
	scanf("%c", &stop);
		
	return 0;
}

void ErrorHandling(char *message)
{
	fputs(message, stderr);
	fputc('\n', stderr);
	exit(1);
}
