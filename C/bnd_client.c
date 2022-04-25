/*
 * bnd_client.c
 */

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>
#include <arpa/inet.h>
#include <sys/types.h>
#include <sys/socket.h>

void error_handling(char *message);

int main(int argc, char **argv)
{
	int sock;  
	int str_len, i;
	struct sockaddr_in serv_addr;
	
	char msg1[]="Hello Everybody";
	char msg2[]="I am so happy!!!";
	char message[10];
	
	if(argc!=3){
		printf("Usage : %s <IP> <port>\n", argv[0]);
		exit(1);
	}
	
	sock=socket(PF_INET, SOCK_STREAM, 0);   
	if(sock == -1)
		error_handling("socket() error");
	
	memset(&serv_addr, 0, sizeof(serv_addr));
	serv_addr.sin_family=AF_INET;
	serv_addr.sin_addr.s_addr=inet_addr(argv[1]);
	serv_addr.sin_port=htons(atoi(argv[2]));
	
	if( connect(sock, (struct sockaddr*)&serv_addr, sizeof(serv_addr))==-1 )
		error_handling("connect() error!");
	
	write(sock, msg1, strlen(msg1)); /* 메시지 1차 전송 */
	write(sock, msg2, strlen(msg2)); /* 메시지 2차 전송 */
	sleep(10);
	
	for(i=0; i<4;i++) {			   /* 메시지 총 4번 수신 */
		str_len=read(sock, message, sizeof(message)-1);
		message[str_len]=0;
		printf("서버로부터 전송된 메시지 : %s \n", message);
	}
	
	close(sock);
	return 0;
}

void error_handling(char *message)
{
	fputs(message, stderr);
	fputc('\n', stderr);
	exit(1);
}
