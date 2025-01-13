use std::collections::BTreeMap;

pub fn transform(h: &BTreeMap<i32, Vec<char>>) -> BTreeMap<char, i32> {
    let mut result = BTreeMap::new();
    for (k, v) in h.iter() {
        for val in v {
            result.insert(val.to_ascii_lowercase(), *k);
        }
    }
    result
}
