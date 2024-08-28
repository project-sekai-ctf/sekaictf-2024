#ifndef COMPANY_HPP 
#define COMPANY_HPP 

#include "declarations.hpp"
#include <vector>
#include <string>
#include <cstdint>

class Company {
public:
    Company(std::string company_name, uint64_t company_budget);
    Company(std::string company_name) : Company(company_name, 1000) {};
    Company() : Company("", 1000) {};
    ~Company();

    uint64_t number_of_projects();
    uint64_t number_of_workers();

    std::string& get_company_name();
    uint64_t get_company_budget();
    uint64_t get_company_age();

    Project* add_project(Project *project);
    void remove_project(Project *project);
    void remove_projects();
    Project* get_project_by_name(std::string project_name);
    Worker* hire_worker(Worker *worker, Project *project);
    Worker* get_worker_by_name(std::string worker_name);
    void move_worker(Worker *worker, Project* new_project);
    void fire_worker(Worker *worker);
    void elapse_week();

private:
    std::string company_name {""};
    uint64_t company_budget {1000};
    uint64_t company_age {0};
    std::vector<Project*> projects {};
};

#endif
