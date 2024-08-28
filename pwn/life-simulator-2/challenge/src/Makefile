CXX = g++
CXXFLAGS = -std=c++20 -Wall -Wextra
TARGET = life_simulator_2
SRCS = main.cpp Company.cpp Project.cpp Worker.cpp

all: clean $(TARGET)

$(TARGET):
	$(CXX) $(CXXFLAGS) -o $(TARGET) $(SRCS)

clean:
	rm -f $(TARGET)

.PHONY: all clean

