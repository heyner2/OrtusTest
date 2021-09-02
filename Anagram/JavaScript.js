
function Getanagram(one, two) {
    var flag = false;

    var arr = one.value.split('');
    var arr2 = two.value.split('');
    var word = "";
    var counter = 0;
    var count = 0;

    for (var item of arr2) {
        if (item !== " ") {
            word += item;
        }
    }



    if (arr.length == word.length) {
        flag = true;
        arr2 = word.split('');
    }


    if (flag) {
        for (var i = 0; i < arr.length; i++) {

            for (var item of arr) {
                if (arr[i] == item) {
                    counter++;
                }
            }

            for (var item of arr2) {
                if (arr[i] == item) {
                    count++;
                }
            }

            if (count == counter) {
                count = 0;
                counter = 0;
            } else {
                flag = false;
                break;
            }
        }
    }

    return flag;



}