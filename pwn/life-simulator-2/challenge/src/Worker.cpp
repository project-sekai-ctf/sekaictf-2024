

#include "Company.hpp"
#include "Project.hpp"
#include "Worker.hpp"
#include <iostream>
#include <vector>
#include <string>
#include <cstdint>

Worker::Worker(std::string name, Project *project, uint64_t salary) {
    this->name = name;
    this->project = project;
    this->salary = salary;
}

Worker::~Worker() {
    this->name.clear();
    this->project = nullptr;
    this->salary = 0;
}

uint64_t Worker::get_salary() {
    return this->salary;
}

std::string& Worker::get_name() { 
    return this->name;
}

Project* Worker::get_project() { 
    return this->project;
}

void Worker::set_project(Project *project) {
    this->project = project;
}

void Worker::info() {
    std::cout << "" << std::endl;
}
