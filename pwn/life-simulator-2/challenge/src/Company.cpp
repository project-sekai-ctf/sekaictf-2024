

#include "Company.hpp"
#include "Project.hpp"
#include "Worker.hpp"
#include <vector>
#include <string>
#include <cstdint>
#include <algorithm>

Company::Company(std::string company_name, uint64_t company_budget) { 
    this->company_name = company_name;
    this->company_budget= company_budget;
}

Company::~Company() { 
    this->company_name.clear();
    this->projects.clear();
    this->company_budget = 0;
}

std::string& Company::get_company_name() {
    return this->company_name;
}

uint64_t Company::get_company_budget() {
    return this->company_budget;
}

uint64_t Company::get_company_age() {
    return this->company_age;
}

uint64_t Company::number_of_projects() {
    return this->projects.size();
}

uint64_t Company::number_of_workers() {
    uint64_t res = 0;
    for(auto project : this->projects) {
        res += project->number_of_workers();
    }
    return res;
}

Project* Company::add_project(Project *project) {
    return this->projects.emplace_back(project);
}

void Company::remove_project(Project *project) {
    this->projects.erase(std::remove(this->projects.begin(), this->projects.end(), project), this->projects.end());
}

void Company::remove_projects() {
    for(auto it : this->projects) {
        delete it;
    }
    this->projects.clear();
}

Project* Company::get_project_by_name(std::string project_name) {
    for(auto it : this->projects) {
        if(it->get_project_name() == project_name) {
            return it; 
        }
    }
    return nullptr;
}

Worker* Company::hire_worker(Worker *worker, Project *project) {
    for(auto it : this->projects) {
        if(it == project) {
            return it->add_worker(worker);
        }
    }
    return nullptr;
}

Worker* Company::get_worker_by_name(std::string worker_name) {
    Worker *worker = nullptr;
    for(auto it : this->projects) {
        worker = it->get_worker_by_name(worker_name);
        if(worker != nullptr) break;
    }
    return worker;
}

void Company::move_worker(Worker *worker, Project *new_project) {
    Project *old_project = worker->get_project();
    old_project->remove_worker(worker);
    new_project->add_worker(worker);
    worker->set_project(new_project);
}

void Company::fire_worker(Worker *worker) {
    Project *project = worker->get_project();
    project->remove_worker(worker);
}

void Company::elapse_week() {
    uint64_t total_profit = 0;
    for(auto it : this->projects) {
        total_profit += it->generate_profit() - it->worker_pay();
    }
    this->company_budget += total_profit;
    this->company_age += 1;
}
