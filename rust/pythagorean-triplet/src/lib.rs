use std::collections::HashSet;

pub fn find(sum: u32) -> HashSet<[u32; 3]> {
    let mut result: HashSet<[u32; 3]> = HashSet::new();

    for a in 1..sum / 2 {
        for b in a + 1..sum / 2 {
            let c = sum - a - b;
            if a * a + b * b == c * c {
                result.insert([a, b, c]);
            }
        }
    }

    return result;
}
