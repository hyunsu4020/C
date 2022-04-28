/*
 * echo_client.c
 */

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>
#include <errno.h>				// errno.h ���� include
#include <arpa/inet.h>
#include <sys/types.h>
#include <sys/socket.h>

#define BUFSIZE 1024
void error_handling(char *message);

int main(int argc, char **argv)
{
	int sock;
	char message[BUFSIZE];
	int str_len;
	struct sockaddr_in serv_addr;

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
	
	if(connect(sock, (struct sockaddr*)&serv_addr, sizeof(serv_addr))==-1)
		error_handling("connect() error!");
	
	while(1) {
		/* �޼��� �Է�, ���� */
		fputs("������ �޽����� �Է� �ϼ��� (q to quit) : ", stdout);
		fgets(message, BUFSIZE, stdin);
		
		if(!strcmp(message,"q\n"))	break;
		write(sock, message, strlen(message));   // s="hello"; sizeof(s): 6, strlen(s): 5
		
		/* �޼��� ����, ��� */
		str_len=read(sock, message, BUFSIZE-1);
		message[str_len]='\0';
		printf("�����κ��� ���۵� �޽��� : %s \n", message);
	}
	
	close(sock);
	return 0;
}

void error_handling(char *message)
{
	fputs(message, stderr);
	fputc('\n', stderr);
	printf("Error Code(%d): %s\n", errno, strerror(errno));   // �������� errno�� Error Code�� ����
	exit(1);
}

