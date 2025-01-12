pub fn is_armstrong_number(num: u32) -> bool {
    let digits = num.to_string();
    let count = digits.len() as u32;
    let calc: u32 = digits
        .chars()
        .filter_map(|c| c.to_digit(10))
        .map(|d| d.pow(count))
        .sum();

    calc == num
}
