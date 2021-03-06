/*
 * echo_server_listen_win.c
 */

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <winsock2.h>

#define BUFSIZE 1024
void ErrorHandling(char *message);

int main(int argc, char **argv)
{
  WSADATA wsaData;
  SOCKET hServSock;
  SOCKET hClntSock;
  char message[BUFSIZE];
  int strLen;

  SOCKADDR_IN servAddr;
  SOCKADDR_IN clntAddr;
  int clntAddrSize;

  if(argc!=2){
    printf("Usage : %s <port>\n", argv[0]);
    exit(1);
  }

  if(WSAStartup(MAKEWORD(2, 2), &wsaData) != 0) /* Load Winsock 2.2 DLL */
		ErrorHandling("WSAStartup() error!"); 

  hServSock=socket(PF_INET, SOCK_STREAM, 0);   
  if(hServSock == INVALID_SOCKET)
    ErrorHandling("socket() error");
 
  memset(&servAddr, 0, sizeof(servAddr));
  servAddr.sin_family=AF_INET;
  servAddr.sin_addr.s_addr=htonl(INADDR_ANY);
  servAddr.sin_port=htons(atoi(argv[1]));

  if(bind(hServSock, (SOCKADDR*) &servAddr, sizeof(servAddr))==SOCKET_ERROR)
    ErrorHandling("bind() error");

  if(listen(hServSock, 2)==SOCKET_ERROR)	// 큐의 크기를 2로 지정함. 
    ErrorHandling("listen() error");

  printf("Press Any Key to Continue : ");
  getchar(); 

  while (1) 
  {
	clntAddrSize=sizeof(clntAddr);    
	hClntSock=accept(hServSock, (SOCKADDR*)&clntAddr,&clntAddrSize);
	if(hClntSock==INVALID_SOCKET)
		ErrorHandling("accept() error");
  
	while( (strLen=recv(hClntSock, message, BUFSIZE, 0)) != 0){ /* 데이터 수신 및 전송 */
		printf("Client message Received.\n");
		send(hClntSock, message, strLen, 0);
	}
	closesocket(hClntSock);
  }

  WSACleanup();
  return 0;
}

void ErrorHandling(char *message)
{
  fputs(message, stderr);
  fputc('\n', stderr);
  exit(1);
}