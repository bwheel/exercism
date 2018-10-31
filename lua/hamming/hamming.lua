local hamming = {}

function hamming.compute(seq1, seq2)
    local result = false;
    for i = 1, seq1.length() do
        local e1 = string.sub(seq1, i, i)
        local e2 = string.sub(seq2, i, i)
        result = result & e1 == e2
    end
end

return hamming