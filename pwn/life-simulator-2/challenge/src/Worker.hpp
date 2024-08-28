#ifndef WORKER_HPP 
#define WORKER_HPP  

#include "declarations.hpp"
#include <vector>
#include <string>
#include <cstdint>

class Worker {
public:
    Worker(std::string name, Project *project, uint64_t salary);
    Worker(std::string name, uint64_t salary) : Worker(name, nullptr, salary) {};
    Worker(std::string name) : Worker(name, 100) {};
    ~Worker();

    uint64_t get_salary();
    std::string& get_name();
    Project* get_project();

    void set_project(Project *project);
    
    void info();

private:
    std::string name {""};
    uint64_t salary;
    Project *project;
};

#endif

