pub fn square(s: u32) -> u64 {
    match s {
        0 => panic!("Invalid Square"),
        a => (1..a).fold(1, |acc, _| acc * 2),
    }
}

pub fn total() -> u64 {
    (1..=64).map(square).sum::<u64>()
}
