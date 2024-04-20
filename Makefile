app=CryptoBot
version=net8.0
os=$(shell uname -s)
sources=$(wildcard */*.fs */*/*.fs */*.fsproj *.sln)
files=$(wildcard */*.fs */*/*.fs *.bat Makefile */*.fsproj *.sln .gitignore)

ifeq ($(os), Linux)
	runtime=linux-x64
	inp=
	out=.bin
endif

ifeq ($(os), Darwin)
	runtime=osx-x64
	inp=
	out=.bin
endif

ifeq ($(os), CYGWIN)
	runtime=win-x64
	inp=.exe
	out=.exe
endif

ifeq ($(os), MINGW)
	runtime=win-x64
	inp=.exe
	out=.exe
endif


debug: ${sources}
	dotnet publish -c Debug -r ${runtime} -p:PublishSingleFile=true \
		--self-contained true ${app}/${app}.fsproj
	cp ./${app}/bin/Debug/${version}/${runtime}/publish/${app}${inp} ${app}${out}

release: ${sources}
	dotnet publish -c Release -r ${runtime} -p:PublishSingleFile=true \
		--self-contained true ${app}/${app}.fsproj
	cp ./${app}/bin/Release/${version}/${runtime}/publish/${app}${inp} ${app}${out}

print.ps: ${sources}
	a2ps -o $@ --font-size=10 -R --columns=1 ${source}

print.pdf: print.ps
	ps2pdf -o $@ $^

clean:
	rm -rf */bin */obj *.bin *.exe *.log print.pdf print.ps
