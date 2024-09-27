Uses crt;
Const n = 6;
Var a,b,c :array [1..n]of real;
        i :integer;
        S :real;
Begin
  Randomize;
  S:=0;
  for i:=1 to n do
  begin
    GoToXY(5*i+10,4);
    a[i]:=random(10);
    b[i]:=random(10);
    writeln (a[i]);
    S:=S+a[i]*b[i];
  end;
  for i:=1 to n do
  begin
    GoToXY (5*i+10,8);
    writeln (b[i]);
  end;
  for i:=1 to n do
  begin
    GoToXY(5*i+10,12);
    c[i]:=a[i]*b[i];
    writeln (c[i]);    
  end;   
  writeln (S);
  
end.