local hamming = {}

function hamming.compute(seq1, seq2)
    local result = 0;
    if seq1:len() ~= seq2:len() then
        result = -1
    else
        for i = 1, #seq1 do
            local e1 = seq1:sub(i, i)
            local e2 = seq2:sub(i, i)
            if e1 ~= e2 then 
                result = result + 1
            end
        end
    end
    return result
end

return hamming