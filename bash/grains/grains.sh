#!/usr/bin/env bash

# This option will make the script exit when there is an error
set -o errexit
# This option will make the script exit when it tries to use an unset variable
set -o nounset

main() {
    case $1 in
    [1-9]|1[0-9]|2[0-9]|3[0-9]|4[0-9]|5[0-9]|6[0-3])
      echo $((2**$(($1-1))))
      return 0
    ;;
    64)
      # 64 causes overflow and is returned as a negative, when calculated, so it's hardcoded.
      echo '9223372036854775808'
      return 0
    ;;
    "total")
      echo "18446744073709551615"
      return 0
    ;;
    *)
      echo "Error: invalid input"
      return 1
    esac
  #fi
  
  }

  main "$@"