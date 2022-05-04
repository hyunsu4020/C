/*
 * low_read.c
 */

#include <stdio.h>
#include <unistd.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <fcntl.h>

#define BUFSIZE 100

void error_handling(char* message);

int main(void)
{
	int fildes;
	char buf[BUFSIZE];
	
	fildes=open("data.txt", O_RDONLY);  /* data.txt라는 이름의 파일 오픈 */
	if( fildes==-1)
		error_handling("open() error!");
	
	printf("오픈 한 파일의 파일 디스크립터는 %d 입니다.\n" , fildes);
	
	if(read(fildes, buf, sizeof(buf))==-1)  /* 파일에 존재하는 내용을 buf로 읽어 들인다. */
		error_handling("read() error!");

	printf("파일의 내용 : %s", buf);
	
	close(fildes);
	return 0;
}

void error_handling(char* message)
{
	fputs(message, stderr);
	fputc('\n', stderr);
	exit(1);
}