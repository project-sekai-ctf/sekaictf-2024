#ifndef PROJECT_HPP 
#define PROJECT_HPP  

#include "declarations.hpp"
#include <vector>
#include <string>
#include <cstdint>

#define PROFIT_RATIO 2.3

class Project {
public:
    Project(std::string project_name, Company *company, uint64_t profit_per_week);
    Project(std::string project_name, Company *company) : Project(project_name, company, 100) {};
    Project(std::string project_name) : Project(project_name, nullptr) {};
    Project() : Project("", nullptr) {};
    ~Project();

    uint64_t number_of_workers();

    Company* get_company();
    uint64_t get_profit_per_week();

    Worker* add_worker(Worker *worker);
    Worker* get_worker_by_name(std::string worker_name);
    void remove_worker(Worker *worker);
    uint64_t generate_profit();
    uint64_t worker_pay();

    std::string& get_project_name();

private:
    std::string project_name {""};
    uint64_t profit_per_week { 100 };
    std::vector<Worker*> workers {};
    Company *company { nullptr };
};

#endif

