#include <iostream>
#include <cstring>

extern "C" __declspec(dllexport) void hyperdbg_event_forwarding(const char* buffer_message, unsigned int buffer_length) {
    if (buffer_message == nullptr) {
        std::cerr << "Error: buffer_message is null." << std::endl;
        return;
    }

    // Safely convert C-style string to std::string
    std::string str_buffer(buffer_message, buffer_length);

    std::cout << "buffer length: " << buffer_length << " | buffer message: " << str_buffer << std::endl;
}