use std::ffi::CStr;
use std::os::raw::c_char;

#[no_mangle]
pub extern "C" fn hyperdbg_event_forwarding(buffer_message: *const c_char, buffer_length: u32) -> () {

    let c_str = unsafe { CStr::from_ptr(buffer_message) };
    let str_buffer = c_str.to_str().unwrap_or("");

    println!("buffer length: {} | buffer message : {}", buffer_length, str_buffer)
}
