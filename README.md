# CSharp-Resaltador-Lexico

Estados Inferiores a 100:
-Estados de transicion (no finales)

Estados Mayores a 100 y menores que 200:
-Palabras Reservadas:
1. bool    q101 (termina con espacio)
2. int     q102 (termina con espacio)
3. char    q103 (termina con espacio)
4. string  q104 (termina con espacio)
5. true    q105 (termina con espacio)
6. false   q106 (termina con espacio)

Estados mayores a 200 y menores que 300:
-Caracteres Especiales:
1. + / -                   q201 (termina con espacio) -> operador aritmético
2. =                       q202 (termina con espacio) -> operador de asignacion

Estados mayores a 300 y menores que 400:
-Cadena de caracteres (string)
1. " + (a-z)* + " + ;      q301 -> "palabra"; (para string)

-Caracter (char)
2. ' + (a-z) + ' + ;       q302 -> 'a'; (para char)

-Numero (int)
3. (0-9) + (0-9)* + ;      q303 -> 98; (para int)