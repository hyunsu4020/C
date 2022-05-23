/*
 * pipe1.c
 */

#include <stdio.h>
#include <unistd.h>
#include <stdlib.h>

#define BUFSIZE 30

int main(int argc, char **argv)
{
  int fd[2];
  char buffer[BUFSIZE];
  pid_t pid;
  int state;

  state = pipe(fd);
  if(state == -1) {
    puts("pipe() error");
    exit(1);
  }

  pid = fork();

  if(pid == -1){
    puts("fork() error");
    exit(1);
  }
  else if(pid==0){
    printf("Child[pid=%d]: Sending Data ... \n", getpid());  
    write(fd[1], "Good\n", 6);
  }
  else{
    printf("Parent[pid=%d]: ", getpid());  
	read(fd[0], buffer, BUFSIZE);
    puts(buffer);
  }

  return 0;
}

