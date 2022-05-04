/*
 * low_open.c
 */

#include <stdio.h>
#include <unistd.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <fcntl.h>

void error_handling(char* message);

int main(void)
{
	int fildes;
	char buf[]="Let's go!\n";
	
	/* data.txt라는 이름의 파일 생성 */
	fildes=open("data.txt", O_CREAT|O_RDWR|O_TRUNC);

	if( fildes==-1)
		error_handling("open() error!");
	printf("생성 된 파일의 파일 디스크립터는 %d 입니다\n", fildes);

	/* 생성한 파일에 buf의 내용 전달 */
	if(write(fildes, buf, sizeof(buf))==-1)
		error_handling("write() error!");

	close(fildes);
	return 0;
}

void error_handling(char* message)
{
	fputs(message, stderr);
	fputc('\n', stderr);
	exit(1);
}

