Uses crt;
Const n = 6;
Var a :array [1..n]of real;
        i :integer;
        z :real;
Begin
  Randomize;
  for i:=1 to n do
  begin
    GoToXY(5*i+10,4);
    a[i]:=random(10);
    writeln (a[i]);
  end;
  z:=a[1];
  for i:=1 to n do
  if z > a[i] then z:= a[i];
  

  writeln (z);
  
end.