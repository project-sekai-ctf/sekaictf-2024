

#include "Company.hpp"
#include "Project.hpp"
#include "Worker.hpp"
#include <vector>
#include <string>
#include <cstdint>
#include <algorithm>
#include <cmath>

Project::Project(std::string project_name, Company *company, uint64_t profit_per_week) { 
    this->project_name = project_name;
    this->company = company;
    this->profit_per_week = profit_per_week;
}

Project::~Project() { 
    this->project_name.clear();
    this->workers.clear();
    this->company = nullptr;
    this->profit_per_week = 0;
}

std::string& Project::get_project_name() {
    return this->project_name;
}

Company* Project::get_company() {
    return this->company;
}

uint64_t Project::get_profit_per_week() {
    return this->profit_per_week;
}

uint64_t Project::number_of_workers() {
    return this->workers.size();
}

Worker* Project::add_worker(Worker *worker) {
    return this->workers.emplace_back(worker);
}

Worker* Project::get_worker_by_name(std::string worker_name) {
    for(auto worker : this->workers) {
        if(worker->get_name() == worker_name) {
            return worker;
        }
    }
    return nullptr;
}

void Project::remove_worker(Worker *worker) {
    this->workers.erase(std::remove(this->workers.begin(), this->workers.end(), worker), this->workers.end());
}

uint64_t Project::generate_profit() {
    return this->profit_per_week * std::pow((long double)PROFIT_RATIO, this->number_of_workers());
}

uint64_t Project::worker_pay() {
    uint64_t total_worker_pay = 0;
    for(auto it : this->workers) {
        total_worker_pay += it->get_salary();
    }
    return total_worker_pay;
}
