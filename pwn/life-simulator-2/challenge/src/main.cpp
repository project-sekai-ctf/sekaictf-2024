

#include "Company.hpp"
#include "Project.hpp"
#include "Worker.hpp"
#include <vector>
#include <iostream>
#include <sstream>
#include <algorithm>

uint64_t total_net_worth = 10000;
std::vector<Company*> companies;
std::vector<Worker*> workers;

void add_company(std::istringstream& iss) {
    std::string company_name = "";
    uint64_t company_budget = 0;
    iss >> company_name >> company_budget;
    if(!iss.good()) {
        std::cerr << "ERR: Invalid Value" << std::endl;
        return;
    }
    if(company_budget < 1000 || company_budget > total_net_worth) {
        std::cerr << "ERR: Invalid Value" << std::endl;
        return;
    }
    for(auto it : companies) {
        if(it->get_company_name() == company_name) {
            std::cerr << "ERR: Invalid Value" << std::endl;
            return;
        }
    }
    Company *new_company = new Company(company_name, company_budget);
    companies.emplace_back(new_company);
    total_net_worth -= company_budget;
    std::cerr << "INFO: Success" << std::endl;
    return;
}

void sell_company(std::istringstream& iss) {
    std::string company_name = "";
    iss >> company_name;
    if(!iss.good()) {
        std::cerr << "ERR: Invalid Value" << std::endl;
        return;
    }
    Company *company_to_remove = nullptr;
    for(auto it : companies) {
        if(it->get_company_name() == company_name) {
            company_to_remove = it;
            break;
        }
    }
    if(company_to_remove == nullptr) {
        std::cerr << "ERR: Not Exist" << std::endl;
        return;
    }
    if(!(company_to_remove->number_of_workers() == 0 || company_to_remove->get_company_budget() == 0)) {
        std::cerr << "ERR: Not Allowed" << std::endl;
        return;
    }
    total_net_worth += company_to_remove->get_company_budget();
    companies.erase(std::remove(companies.begin(), companies.end(), company_to_remove), companies.end());
    company_to_remove->remove_projects();
    delete company_to_remove;
    std::cerr << "INFO: Success" << std::endl;
    return;
}

void add_project(std::istringstream& iss) {
    std::string company_name = "", project_name = "";
    uint64_t project_profit_per_week = 0;
    iss >> company_name >> project_name >> project_profit_per_week;
    if(!iss.good()) {
        std::cerr << "ERR: Invalid Value" << std::endl;
        return;
    }
    Company *company = nullptr;
    for(auto it : companies) {
        if(it->get_company_name() == company_name) {
            company = it;
            break;
        }
    }
    if(company == nullptr) {
        std::cerr << "ERR: Not Exist" << std::endl;
        return;
    }
    if(project_profit_per_week < 500 || project_profit_per_week > 1000000) {
        std::cerr << "ERR: Invalid Value" << std::endl;
        return;
    }
    if(company->get_project_by_name(project_name) != nullptr) {
        std::cerr << "ERR: Invalid Value" << std::endl;
        return;
    }
    Project *project = new Project(project_name, company, project_profit_per_week);
    company->add_project(project);
    std::cerr << "INFO: Success" << std::endl;
    return;
}

void remove_project(std::istringstream& iss) {
    std::string company_name = "", project_name = "";
    iss >> company_name >> project_name;
    if(!iss.good()) {
        std::cerr << "ERR: Invalid Value" << std::endl;
        return;
    }
    Company *company = nullptr;
    for(auto it : companies) {
        if(it->get_company_name() == company_name) {
            company = it;
            break;
        }
    }
    if(company == nullptr) {
        std::cerr << "ERR: Not Exist" << std::endl;
        return;
    }
    Project *project = company->get_project_by_name(project_name);
    if(project == nullptr) {
        std::cerr << "ERR: Not Exist" << std::endl;
        return;
    }
    if(project->number_of_workers() != 0) {
        std::cerr << "ERR: Not Allowed" << std::endl;
        return;
    }
    company->remove_project(project);
    delete project;
    std::cerr << "INFO: Success" << std::endl;
    return;
}

void hire_worker(std::istringstream& iss) {
    std::string company_name = "", project_name = "", worker_name = "";
    uint64_t salary = 0;
    iss >> company_name >> project_name >> worker_name >> salary;
    if(!iss.good()) {
        std::cerr << "ERR: Invalid Value" << std::endl;
        return;
    }
    Company *company = nullptr;
    for(auto it : companies) {
        if(it->get_company_name() == company_name) {
            company = it;
            break;
        }
    }
    if(company == nullptr) {
        std::cerr << "ERR: Not Exist" << std::endl;
        return;
    }
    Worker *worker = nullptr;
    for(auto it : workers) {
        if(it->get_name() == worker_name) {
            worker = it;
            break;
        }
    }
    if(worker != nullptr) {
        std::cerr << "ERR: Invalid Value" << std::endl;
        return;
    }
    Project* project = company->get_project_by_name(project_name);
    if(project == nullptr) {
        std::cerr << "ERR: Not Exist" << std::endl;
        return;
    }
    if(project->get_worker_by_name(worker_name) != nullptr) {
        std::cerr << "ERR: Invalid Value" << std::endl;
        return;
    }
    if(salary > 100) {
        std::cerr << "ERR: Invalid Value" << std::endl;
        return;
    }
    Worker* new_worker = new Worker(worker_name, project, salary);
    project->add_worker(new_worker);
    workers.emplace_back(new_worker);
    std::cerr << "INFO: Success" << std::endl;
    return;
}

void fire_worker(std::istringstream& iss) {
    std::string worker_name = "";
    iss >> worker_name;
    if(!iss.good()) {
        std::cerr << "ERR: Invalid Value" << std::endl;
        return;
    }
    Worker* worker = nullptr;
    for(auto it : workers) {
        if(it->get_name() == worker_name) {
            worker = it;
            break;
        }
    }
    if(worker == nullptr) {
        std::cerr << "ERR: Not Exist" << std::endl;
        return;
    }
    Project* project = worker->get_project();
    Company* company = project->get_company();
    company->fire_worker(worker);
    workers.erase(std::remove(workers.begin(), workers.end(), worker), workers.end());
    delete worker;
    std::cerr << "INFO: Success" << std::endl;
    return;
}

void move_worker(std::istringstream& iss) {
    std::string worker_name = "", new_project_name = "";
    iss >> worker_name >> new_project_name;
    if(!iss.good()) {
        std::cerr << "ERR: Invalid Value" << std::endl;
        return;
    }
    Worker* worker = nullptr;
    for(auto it : workers) {
        if(it->get_name() == worker_name) {
            worker = it;
            break;
        }
    }
    if(worker == nullptr) {
        std::cerr << "ERR: Not Exist" << std::endl;
        return;
    }
    Project* old_project = worker->get_project();
    Company* company = old_project->get_company();
    Project* new_project = company->get_project_by_name(new_project_name);
    if(new_project == nullptr) {
        std::cerr << "ERR: Not Exist" << std::endl;
        return;
    }
    company->move_worker(worker, new_project);
    std::cerr << "INFO: Success" << std::endl;
    return;
}

void worker_info(std::istringstream& iss) {
    std::string worker_name = "";
    iss >> worker_name;
    if(!iss.good()) {
        std::cerr << "ERR: Invalid Value" << std::endl;
        return;
    }
    Worker* worker = nullptr;
    for(auto it : workers) {
        if(it->get_name() == worker_name) {
            worker = it;
            break;
        }
    }
    if(worker == nullptr) {
        std::cerr << "ERR: Not Exist" << std::endl;
        return;
    }
    std::cout << "Worker details: " << std::endl;
    std::cout << "Name: " << worker->get_name() << std::endl;
    std::cout << "Salary: " << worker->get_salary() << std::endl;
    std::cout << "Project details: " << std::endl;
    std::cout << "Project name: " << worker->get_project()->get_project_name() << std::endl;
    std::cout << "Project profit per week: " << worker->get_project()->get_profit_per_week() << std::endl;
    std::cout << "Project workers count: " << worker->get_project()->number_of_workers() << std::endl;
    std::cout << "Company details: " << std::endl;
    std::cout << "Company name: " << worker->get_project()->get_company()->get_company_name() << std::endl;
    std::cout << "Company budget: " << worker->get_project()->get_company()->get_company_budget() << std::endl;
    std::cout << "Company age: " << worker->get_project()->get_company()->get_company_age() << std::endl;
    std::cout << "Company project count: " << worker->get_project()->get_company()->number_of_projects() << std::endl;
}

void elapse_week() {
    for(auto it : companies) {
        it->elapse_week();
    }
}

void print_earnings() {
    for(auto it : companies) {
        std::cout << "● " << it->get_company_name() << " Company Value: " << it->get_company_budget() << " UP▲" << std::endl;
    }
}

void init() {
    setvbuf(stdout,0,2,0);
    setvbuf(stderr,0,2,0);
}

int main() {
    init();
    std::string input = "";
    std::string function = "";
    while(1) {
        print_earnings();
        std::getline(std::cin, input);
        std::istringstream iss(input + '\n');
        iss >> function;
        if(!iss.good()) {
            std::cerr << "ERR: Input" << std::endl;
            break;
        }
        if(function == "exit") break;
        else if(function == "add_company")     add_company(iss);
        else if(function == "sell_company")    sell_company(iss);
        else if(function == "add_project")     add_project(iss);
        else if(function == "remove_project")  remove_project(iss);
        else if(function == "hire_worker")     hire_worker(iss);
        else if(function == "fire_worker")     fire_worker(iss);
        else if(function == "move_worker")     move_worker(iss);
        else if(function == "worker_info")     worker_info(iss);
        else if(function == "elapse_week")     elapse_week();
        else {
            std::cerr << "ERR: Invalid Function" << std::endl;
        }
    }
    return 0;
}
