/*
Dado dos numeros enteros n,p tales que p >= 0 computar n^p, es decir elevar n a la
p-esima potencia.

n ^ p = {
    1, si p es 0
    n * n^(p-1), si p > 0
}

Tambien
n ^ p = {
    1, si p es 0,
    n ^ (p-1) * n, si p es impar
    (n ^ (p/2)) ^ 2, si p es par
}
*/
static class Potencia{
    //Complejidad O(p)
    public static int PotenciaLineal(int n,int p){
        if(p == 0){
            if(n==0)throw new Exception("0^0 does not defined");
            return 1;
        }
        return n * PotenciaLineal(n,p-1);
    }
    //Complejidad O(log p)
    public static int PotenciaLog(int n,int p){
        if(p == 0){
            if(n==0)throw new Exception("0^0 does not defined");
            return 1;
        }
        int pot = PotenciaLog(n,p/2);//n ^ (p/2)
        pot *= pot;// n^(p/2) * n^(p/2) = n^p
        if(p % 2 == 1)pot *= n;
        return pot;
    }
}